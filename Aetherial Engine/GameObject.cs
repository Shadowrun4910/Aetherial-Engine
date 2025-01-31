using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class GameObject
{
    public PictureBox pictureBox { get; set; }

    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int DefaultNum { get; set; }
    public string ImagePath { get; set; }
    public int Zorder { get; set; }
    public List<string> AttachedScripts { get; set; }

    public event Action OnPropertyChanged;

    public GameObject(Form parentForm, string name, int x, int y, int width, int height, int zorder, string imagePath = null)
    {
        Name = name;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        DefaultNum = 0;
        ImagePath = null;
        Zorder = zorder;
        AttachedScripts = new List<string>();

        pictureBox = new PictureBox
        {
            Name = name,
            Location = new Point(x, y),
            Size = new Size(width, height),
            BackColor = Color.White,
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
        {
            pictureBox.Image = Image.FromFile(imagePath);
            ImagePath = imagePath;
        }

        parentForm.Controls.Add(pictureBox);
    }

    public void NotifyPropertyChanged()
    {
        OnPropertyChanged?.Invoke();
    }

    public void SetX(int newX)
    {
        if (X != newX)
        {
            X = newX;
            UpdateVisuals();
            NotifyPropertyChanged();
        }
    }

    public void SetY(int newY)
    {
        if (Y != newY)
        {
            Y = newY;
            UpdateVisuals();
            NotifyPropertyChanged();
        }
    }

    public void SetWidth(int newWidth)
    {
        if (Width != newWidth)
        {
            Width = newWidth;
            UpdateVisuals();
            NotifyPropertyChanged();
        }
    }

    public void SetHeight(int newHeight)
    {
        if (Height != newHeight)
        {
            Height = newHeight;
            UpdateVisuals();
            NotifyPropertyChanged();
        }
    }

    public void UpdateVisuals()
    {
        if (pictureBox != null)
        {
            pictureBox.Location = new Point(X, Y);
            pictureBox.Size = new Size(Width, Height);
            pictureBox.Refresh();

            if (!string.IsNullOrEmpty(ImagePath) && System.IO.File.Exists(ImagePath))
            {
                pictureBox.BackColor = Color.Transparent;
                pictureBox.Image = Image.FromFile(ImagePath);
            }
            else if (string.IsNullOrEmpty(ImagePath))
            {
                pictureBox.BackColor = Color.White;
                pictureBox.Image = null;
            }
        }
    }

    public void AttachScript(string scriptName)
    {
        if (!AttachedScripts.Contains(scriptName))
        {
            AttachedScripts.Add(scriptName);
        }
    }

    public void RemoveScript(string scriptName)
    {
        if (AttachedScripts.Contains(scriptName))
        {
            AttachedScripts.Remove(scriptName);
        }
    }
}
