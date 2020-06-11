﻿[System.Serializable]
public class ScreenResolution
{
    public int width;
    public int height;
    public int position;
    
    public ScreenResolution(int width, int height, int position)
    {
        this.width = width;
        this.height = height;
        this.position = position;
    }
    public float getWidth() {
        return width;
    }
    
    public float getHeight() {
        return height;
    }

    public void setWidth(int width)
    {
        this.width = width;
    }
    
    public void setHeight(int height)
    {
        this.height = height;
    }
}