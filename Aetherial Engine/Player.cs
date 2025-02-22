using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using NLua;
using Timer = System.Windows.Forms.Timer;

namespace Aetherial_Engine
{
    public partial class Player : Form
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        List<GameObject> tempObjects = new List<GameObject>();
        private List<GameObject> gameObjects;
        public Lua lua;
        private Timer updateTimer;
        private Engine engine;

        public Player(string fileName, Engine engine)
        {
            InitializeComponent();
            this.engine = engine;
            lua = new Lua();

            LoadState(fileName);
            AddGameObjectsToDisplay();
        }

        private void LogMessage(string message, string messageType = "Info")
        {
            engine?.LogToConsole(message, messageType);
        }

        private void LoadState(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);
                var gameState = JsonSerializer.Deserialize<GameState>(json);

                if (gameState?.GameObjects == null || gameState.GameObjects.Count == 0)
                {
                    return;
                }

                gameObjects = gameState.GameObjects.Select(obj =>
                new GameObject(this, obj.Name, obj.X, obj.Y, obj.Width, obj.Height, obj.Zorder, obj.ImagePath)
                {
                    AttachedScripts = obj.AttachedScripts ?? new List<string>(),
                    ImagePath = obj.ImagePath
                }).ToList();

                foreach (var obj in gameObjects)
                {
                    if (obj == null)
                    {
                        MessageBox.Show("A GameObject in the list is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    lua[obj.Name] = obj;

                    RegisterGameObjectMethodsForObject(obj);

                    InitializeGameLoop();

                    UpdateObjectZOrder(obj);

                    foreach (var scriptName in obj.AttachedScripts)
                    {
                        string scriptPath = Path.Combine("scripts", scriptName + ".lua");

                        if (File.Exists(scriptPath))
                        {
                            try
                            {
                                lua.DoFile(scriptPath);
                            }
                            catch (Exception ex)
                            {
                                LogMessage($"Error loading script {scriptPath}: {ex.Message}", "Error");
                            }
                        }
                        else
                        {
                            LogMessage($"Script not found: {scriptPath}", "Warning");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error loading game state: {ex.Message}", "Error");
            }
        }


        private void RegisterGameObjectMethodsForObject(GameObject obj)
        {
            if (obj == null)
            {
                return;
            }

            try
            {
                lua.RegisterFunction("PrintMessage", this, GetType().GetMethod("PrintMessage"));
                lua.RegisterFunction("KeyCheck", this, GetType().GetMethod("KeyCheck"));
                lua.RegisterFunction("PlaySound", this, GetType().GetMethod("PlaySound"));
                lua.RegisterFunction("CollisionCheck", this, GetType().GetMethod("CollisionCheck"));
                lua.RegisterFunction("CreateObject", this, GetType().GetMethod("CreateObject"));
                lua.RegisterFunction("DeleteObject", this, GetType().GetMethod("DeleteObject"));
                lua.RegisterFunction("HideObject", this, GetType().GetMethod("HideObject"));
                lua.RegisterFunction("ShowObject", this, GetType().GetMethod("ShowObject"));
                lua.RegisterFunction("SetWindow", this, GetType().GetMethod("SetWindow"));
            }
            catch (Exception ex)
            {
                LogMessage($"Error registering methods for {obj.Name}: {ex.Message}", "Error");
            }
        }

        private void AddGameObjectsToDisplay()
        {

            if (gameObjects == null || gameObjects.Count == 0)
            {
                LogMessage("No GameObjects to display.", "Error");
                return;
            }

            foreach (var obj in gameObjects)
            {
                if (obj == null)
                {
                    continue;
                }

                if (obj.pictureBox != null)
                {
                    continue;
                }

                var pictureBox = new PictureBox
                {
                    Name = obj.Name,
                    Location = new Point(obj.X, obj.Y),
                    Size = new Size(obj.Width, obj.Height),
                    BackColor = Color.White
                };

                if (!string.IsNullOrEmpty(obj.ImagePath) && File.Exists(obj.ImagePath))
                {
                    try
                    {
                        pictureBox.Image = Image.FromFile(obj.ImagePath);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"Error loading image for {obj.Name}: {ex.Message}", "Error");
                    }
                }

                this.Controls.Add(pictureBox);

                obj.pictureBox = pictureBox;

            }
        }

        private void UpdateObjectZOrder(GameObject gameObject)
        {
            if (gameObject.pictureBox != null)
            {
                this.Controls.SetChildIndex(gameObject.pictureBox, gameObject.Zorder);
            }
        }

        private void InitializeGameLoop()
        {

            updateTimer = new Timer { Interval = 16 };
            updateTimer.Tick += (sender, e) =>
            {
                if (!updateTimer.Enabled)
                {
                    Console.WriteLine("Timer was stopped, exiting the Tick method.");
                    return;
                }

                if (gameObjects == null)
                {
                    LogMessage("GameObjects list is null during game loop.", "Error");
                    return;
                }

                foreach (var obj in gameObjects)
                {
                    if (obj == null)
                    {
                        LogMessage("GameObject is null in game loop.", "Error");
                        continue;
                    }

                    HandleGameObjectUpdate(obj);
                }

                foreach (var obj in tempObjects)
                {
                    if (obj == null)
                    {
                        return;
                    }

                    HandleGameObjectUpdate(obj);
                }
            };
            updateTimer.Start();

        }

        private void HandleGameObjectUpdate(GameObject obj)
        {
            try
            {
                obj.UpdateVisuals();

                foreach (var scriptName in obj.AttachedScripts)
                {
                    string scriptPath = Path.Combine("scripts", scriptName + ".lua");

                    if (File.Exists(scriptPath))
                    {
                        if (lua["scriptLoaded_" + scriptName] == null)
                        {
                            lua["scriptLoaded_" + scriptName] = true;
                            Console.WriteLine($"Script loaded: {scriptName}");
                        }

                        string onUpdateKey = scriptName + "_onUpdate";
                        LuaFunction onUpdateFunc = lua[onUpdateKey] as LuaFunction;

                        if (onUpdateFunc != null)
                        {
                            Console.WriteLine($"Calling onUpdate for {scriptName}");
                            onUpdateFunc.Call(obj);
                        }
                        else
                        {
                            Console.WriteLine($"No onUpdate function in script: {scriptName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Script not found: {scriptPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage("Error in HandleGameObjectUpdate: " + ex.Message);
            }
        }

        public void PrintMessage(string message)
        {
            LogMessage(message, "Info");
        }

        public bool KeyCheck(string key)
        {
            try
            {
                Keys keyEnum = (Keys)Enum.Parse(typeof(Keys), key, true);
                return (GetAsyncKeyState(keyEnum) & 0x8000) != 0;
            }
            catch
            {
                LogMessage($"Invalid key name: {key}", "Error");
                return false;
            }
        }

        public void SetWindow(int width, int height, string title, string iconPath)
        {
            this.Width = width;
            this.Height = height;
            this.Text = title;

            if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }
            else
            {
                this.Icon = null;
            }
        }

        public bool CollisionCheck(GameObject obj, GameObject obj2)
        {
            if (obj == null || obj2 == null)
                return false;

            return obj.X < obj2.X + obj2.Width &&
           obj.X + obj.Width > obj2.X &&
           obj.Y < obj2.Y + obj2.Height &&
           obj.Y + obj.Height > obj2.Y;
        }

        public GameObject CreateObject(int x, int y, int width, int height, int zorder, string imagePath)
        {
            GameObject newObject = new GameObject(this, "Object" + tempObjects.Count, x, y, width, height, zorder, imagePath);

            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    newObject.pictureBox.Image = Image.FromFile(imagePath);
                    newObject.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    LogMessage($"Error loading image for {newObject.Name}: {ex.Message}", "Error");
                }
            }

            tempObjects.Add(newObject);

            return newObject;
        }

        public void DeleteObject(GameObject obj)
        {
            if (obj == null) return;

            this.Controls.Remove(obj.pictureBox);
        }

        public void HideObject(GameObject obj)
        {
            if (obj == null) return;

            obj.pictureBox.Hide();
        }

        public void ShowObject(GameObject obj)
        {
            if (obj == null) return;

            obj.pictureBox.Show();
        }

        public void PlaySound(string filename, bool loop)
        {
            if (!File.Exists(filename))
            {
                LogMessage($"Sound file not found: {filename}", "Error");
                return;
            }

            try
            {
                var waveOut = new WaveOutEvent();
                var audioFile = new AudioFileReader(filename);

                if (loop)
                {
                    waveOut.PlaybackStopped += (sender, e) =>
                    {
                        audioFile.Position = 0;
                        waveOut.Play();
                    };
                }

                waveOut.Init(audioFile);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                LogMessage($"Error playing sound: {ex.Message}", "Error");
            }
        }


        private void Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateTimer != null && updateTimer.Enabled)
            {
                updateTimer.Enabled = false;
            }
        }

    }
    public class GameObjectState
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ImagePath { get; set; }
        public int Zorder { get; set; }
        public List<string> AttachedScripts { get; set; }
    }
    public class GameState
    {
        public List<GameObjectState> GameObjects { get; set; }
    }
}
