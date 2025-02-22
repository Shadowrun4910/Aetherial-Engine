using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;

namespace Aetherial_Engine
{
    public partial class Engine : Form
    {
        private List<GameObject> gameObjects;
        private bool isSaved = false;
        private string savedgamefile;

        private GameObject selecteddObject;

        public Engine()
        {
            InitializeComponent();
            gameObjects = new List<GameObject>();

            objx_input.TextChanged += (sender, e) => UpdateSelectedObjectProperty<int>(objx_input, (obj, value) => obj.SetX(value));
            objy_input.TextChanged += (sender, e) => UpdateSelectedObjectProperty<int>(objy_input, (obj, value) => obj.SetY(value));
            objwidth_input.TextChanged += (sender, e) => UpdateSelectedObjectProperty<int>(objwidth_input, (obj, value) => obj.SetWidth(value));
            objheight_input.TextChanged += (sender, e) => UpdateSelectedObjectProperty<int>(objheight_input, (obj, value) => obj.SetHeight(value));
        }

        private void createobj_btn_Click_1(object sender, EventArgs e)
        {
            string objectName = PromptForName();

            if (string.IsNullOrEmpty(objectName)) return;

            var obj = new GameObject(this, objectName, 50, 50, 32, 32, -1);
            gameObjects.Add(obj);

            obj.OnPropertyChanged += UpdateObjectProperties;

            MessageBox.Show($"Object '{objectName}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void removeobj_btn_Click(object sender, EventArgs e)
        {
            string objectName = PromptForObjectName();

            if (string.IsNullOrEmpty(objectName))
            {
                MessageBox.Show("You must enter a valid name to remove an object.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GameObject selectedObject = FindObjectByName(objectName);

            if (selectedObject != null)
            {
                this.Controls.Remove(selectedObject.pictureBox);

                gameObjects.Remove(selectedObject);

                MessageBox.Show($"Object '{objectName}' removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objx_input.Enabled = objy_input.Enabled = objwidth_input.Enabled = objheight_input.Enabled = objimage_input.Enabled = false;
                scriptslist.Enabled = attachscript_button.Enabled = removescript_button.Enabled = setimage_btn.Enabled = brtb_btn.Enabled = brtf_btn.Enabled = false;

                UpdateObjectProperties();
            }
            else
            {
                MessageBox.Show($"No object found with the name '{objectName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string PromptForName()
        {
            return Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the new object:", "Object Name", "NewObject").Trim();
        }

        private void properties_btn_Click(object sender, EventArgs e)
        {
            string objectName = PromptForObjectName();
            var selectedObject = FindObjectByName(objectName);

            if (selectedObject == null)
            {
                MessageBox.Show("Invalid or non-existent object name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PopulateObjectProperties(selectedObject);
            EnablePropertyControls();
            UpdateScriptListForObject(selectedObject);
            selecteddObject = selectedObject;
        }

        private void UpdateScriptListForObject(GameObject selectedObject)
        {
            scriptslist.Items.Clear();

            foreach (var script in selectedObject.AttachedScripts)
            {
                scriptslist.Items.Add(script);
            }
        }

        private string PromptForObjectName()
        {
            return Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the existing object:", "Object Name", "");
        }

        private GameObject? FindObjectByName(string objectName)
        {
            foreach (var obj in gameObjects)
            {
                if (obj.Name.Equals(objectName, StringComparison.OrdinalIgnoreCase))
                {
                    return obj;
                }
            }
            return null;
        }

        private void PopulateObjectProperties(GameObject selectedObject)
        {
            objname_input.Text = selectedObject.Name;
            objx_input.Text = selectedObject.X.ToString();
            objy_input.Text = selectedObject.Y.ToString();
            objwidth_input.Text = selectedObject.Width.ToString();
            objheight_input.Text = selectedObject.Height.ToString();
            if (selectedObject.ImagePath != null)
            {
                objimage_input.Text = selectedObject.ImagePath.ToString();
            }
            else
            {
                objimage_input.Clear();
            }
        }

        private void EnablePropertyControls()
        {
            objx_input.Enabled = objy_input.Enabled = objwidth_input.Enabled = objheight_input.Enabled = objimage_input.Enabled = true;
            scriptslist.Enabled = attachscript_button.Enabled = removescript_button.Enabled = setimage_btn.Enabled = brtb_btn.Enabled = brtf_btn.Enabled = true;
        }

        private void UpdateObjectProperties()
        {
            var selectedObject = FindObjectByName(objname_input.Text);
            if (selectedObject != null)
            {
                PopulateObjectProperties(selectedObject);
            }
        }
        private void objx_input_TextChanged(object sender, EventArgs e)
        {
            UpdateSelectedObjectProperty<int>(objx_input, (obj, value) => obj.SetX(value));
        }

        private void objy_input_TextChanged(object sender, EventArgs e)
        {
            UpdateSelectedObjectProperty<int>(objy_input, (obj, value) => obj.SetY(value));
        }

        private void objwidth_input_TextChanged(object sender, EventArgs e)
        {
            UpdateSelectedObjectProperty<int>(objwidth_input, (obj, value) => obj.SetWidth(value));
        }

        private void objheight_input_TextChanged(object sender, EventArgs e)
        {
            UpdateSelectedObjectProperty<int>(objheight_input, (obj, value) => obj.SetHeight(value));
        }

        private void UpdateSelectedObjectProperty<T>(TextBox textBox, Action<GameObject, T> updateAction)
        {
            if (int.TryParse(textBox.Text, out int newValue))
            {
                var selectedObject = FindObjectByName(objname_input.Text);
                selectedObject?.Let(obj => updateAction(obj, (T)(object)newValue));
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetTextBoxToObjectValue(textBox);
            }
        }

        private void ResetTextBoxToObjectValue(TextBox textBox)
        {
            var selectedObject = FindObjectByName(objname_input.Text);
            if (selectedObject != null)
            {
                textBox.Text = selectedObject.DefaultNum.ToString();
            }
        }

        private void attachscript_button_Click(object sender, EventArgs e)
        {
            var selectedObject = FindObjectByName(objname_input.Text);

            if (selectedObject == null)
            {
                MessageBox.Show("No object selected. Please select an object to attach a script.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string scriptName = PromptForScriptName();

            if (string.IsNullOrEmpty(scriptName)) return;

            string scriptDirectory = Path.Combine(Application.StartupPath, "scripts");
            Directory.CreateDirectory(scriptDirectory);
            string scriptPath = Path.Combine(scriptDirectory, scriptName + ".lua");

            if (File.Exists(scriptPath))
            {
                selectedObject.AttachScript(scriptName);
                UpdateScriptList(selectedObject);

                MessageBox.Show($"Existing script '{scriptName}' attached to object '{selectedObject.Name}'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(scriptPath))
                    {
                        sw.WriteLine("--Generated for Aetherial engine");
                    }

                    selectedObject.AttachScript(scriptName);

                    UpdateScriptList(selectedObject);

                    MessageBox.Show($"Script '{scriptName}' created and attached to object '{selectedObject.Name}'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating the script: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private string PromptForScriptName()
        {
            return Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the script to attach:", "Script Name", "NewScript").Trim();
        }

        private void UpdateScriptList(GameObject selectedObject)
        {
            scriptslist.Items.Clear();

            foreach (var script in selectedObject.AttachedScripts)
            {
                scriptslist.Items.Add(script);
            }
        }


        private void removescript_button_Click(object sender, EventArgs e)
        {
            var selectedObject = FindObjectByName(objname_input.Text);

            if (selectedObject == null)
            {
                MessageBox.Show("No object selected. Please select an object to remove a script.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (scriptslist.SelectedItem == null)
            {
                MessageBox.Show("Please select a script to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string scriptName = scriptslist.SelectedItem.ToString();

            var confirmResult = MessageBox.Show($"Are you sure you want to remove the script '{scriptName}' from object '{selectedObject.Name}'?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                selectedObject.RemoveScript(scriptName);

                UpdateScriptList(selectedObject);

                string scriptFilePath = Path.Combine("scripts", scriptName + ".lua");
                if (File.Exists(scriptFilePath))
                {
                    File.Delete(scriptFilePath);
                }

                MessageBox.Show($"Script '{scriptName}' removed from object '{selectedObject.Name}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void play_button_Click(object sender, EventArgs e)
        {
            if (isSaved == false)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Game Files (*.json)|*.json";
                    saveFileDialog.Title = "Aetherial Saver";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveState(saveFileDialog.FileName);

                        isSaved = true;

                        LogToConsole("Session Started!");

                        Player player = new Player(saveFileDialog.FileName, this);
                        player.Show();
                    }
                }
            }
            else
            {
                SaveState(savedgamefile);

                LogToConsole("Session Started!");

                Player player = new Player(savedgamefile, this);
                player.Show();
            }
        }

        private void SaveState(string fileName)
        {
            var gameState = new GameState
            {
                GameObjects = gameObjects.Select(obj => new GameObjectState
                {
                    Name = obj.Name,
                    X = obj.X,
                    Y = obj.Y,
                    Width = obj.Width,
                    Height = obj.Height,
                    ImagePath = obj.ImagePath,
                    AttachedScripts = obj.AttachedScripts,
                    Zorder = obj.Zorder
                }).ToList()
            };

            string json = JsonSerializer.Serialize(gameState, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);

            savedgamefile = fileName;

            isSaved = true;
        }

        private void LoadState(string fileName)
        {
            foreach (var obj in gameObjects)
            {
                if (obj.pictureBox != null)
                {
                    this.Controls.Remove(obj.pictureBox);
                    obj.pictureBox.Dispose();
                }
            }

            gameObjects.Clear();

            string json = File.ReadAllText(fileName);
            var gameState = JsonSerializer.Deserialize<GameState>(json);

            foreach (var objState in gameState.GameObjects)
            {
                var newObject = new GameObject(this, objState.Name, objState.X, objState.Y, objState.Width, objState.Height, objState.Zorder, objState.ImagePath)
                {
                    AttachedScripts = new List<string>(objState.AttachedScripts)
                };

                gameObjects.Add(newObject);

                var pictureBox = new PictureBox
                {
                    Name = newObject.Name,
                    Location = new Point(newObject.X, newObject.Y),
                    Size = new Size(newObject.Width, newObject.Height),
                    BackColor = Color.White
                };

                UpdateObjectZOrder(newObject);

                newObject.pictureBox = pictureBox;
            }

            savedgamefile = fileName;
            isSaved = true;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "JSON Files|*.json",
                Title = "Aetherial Saver"
            })
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveState(saveDialog.FileName);
                    LogToConsole($"File '{Path.GetFileName(saveDialog.FileName)}' has been saved successfully!");
                }
            }
        }

        private void load_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "JSON Files|*.json",
                Title = "Aetherial Loader"
            })
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadState(openDialog.FileName);
                    console.Clear();
                    LogToConsole($"File '{openDialog.SafeFileName}' has loaded successfully!");
                }
            }
        }

        public void LogToConsole(string message, string messageType = "Info")
        {
            if (console == null) return;

            console.AppendText($"[{DateTime.Now:HH:mm:ss}] [{messageType}] {message}\n");
            console.ScrollToCaret();
        }

        private void setimage_btn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(objimage_input.Text) && objimage_input.Text != string.Empty)
            {
                MessageBox.Show("Image destination does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (objimage_input.Text == string.Empty)
            {
                selecteddObject.ImagePath = null;
                selecteddObject.UpdateVisuals();
            }
            else
            {
                selecteddObject.ImagePath = objimage_input.Text;
                selecteddObject.UpdateVisuals();
            }
        }

        private void clrconsole_btn_Click(object sender, EventArgs e)
        {
            console.Clear();
        }

        private void SaveLogs()
        {
            string fileName = "Logs.txt";

            try
            {
                File.WriteAllText(fileName, console.Text);
                Console.WriteLine($"Logs have been saved successfully to {fileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save logs: {ex.Message}");
            }
        }

        private void exlogs_btn_Click(object sender, EventArgs e)
        {
            SaveLogs();
        }

        private void brtf_btn_Click(object sender, EventArgs e)
        {
            if (selecteddObject != null)
            {
                selecteddObject.UpdateVisuals();

                selecteddObject.Zorder += 1;

                UpdateObjectZOrder(selecteddObject);
            }
        }

        private void brtb_btn_Click(object sender, EventArgs e)
        {
            if (selecteddObject != null)
            {
                selecteddObject.UpdateVisuals();

                selecteddObject.Zorder -= 1;

                UpdateObjectZOrder(selecteddObject);
            }
        }

        private void UpdateObjectZOrder(GameObject gameObject)
        {
            if (gameObject.pictureBox != null)
            {
                this.Controls.SetChildIndex(gameObject.pictureBox, gameObject.Zorder);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "JSON Files|*.json",
                Title = "Aetherial Saver"
            })
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveState(saveDialog.FileName);
                    LogToConsole($"File '{Path.GetFileName(saveDialog.FileName)}' has been saved successfully!");
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "JSON Files|*.json",
                Title = "Aetherial Loader"
            })
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadState(openDialog.FileName);
                    console.Clear();
                    LogToConsole($"File '{openDialog.SafeFileName}' has loaded successfully!");
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game engine was developed to test my skills beyond game developement and how quick i could do it.\n\nGame engine made by Shadowrun4910.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static class ObjectExtensions
    {
        public static void Let<T>(this T obj, Action<T> action)
        {
            action(obj);
        }
    }
}
