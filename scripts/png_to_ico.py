from PIL import Image


filename_fullpath = r'C:\projects\C#\DoomSurvivors\scripts\originals\ico\doomguy.png'
img = Image.open(filename_fullpath)
img.save('logo.ico')