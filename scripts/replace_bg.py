from pathlib import Path
from PIL import Image

original_folder = 'originals'
processed_folder = 'processed'

Path('originals').mkdir(parents=True, exist_ok=True)
Path('processed').mkdir(parents=True, exist_ok=True)

original_files = Path('originals').glob('*.png')

for original_file in original_files:
    print(f'processing file: {original_file}')
    
    img = Image.open(original_file)
    rgba = img.convert('RGBA')
    datas = rgba.getdata()


    newData = []

    for item in datas:
        if item == (0,255,255,255):
            newData.append((255, 255, 255, 0))

        else:
            newData.append(item)
            
            
    rgba.putdata(newData)
    rgba.save(f'{processed_folder}/{original_file.name}', 'PNG')