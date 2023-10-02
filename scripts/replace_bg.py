from pathlib import Path
from PIL import Image


alpha_colors = (
    (0,255,255,255), # Cyan
    (255,0,110,255), # Magenta
)

original_folder = 'originals'
processed_folder = 'processed'

Path('originals').mkdir(parents=True, exist_ok=True)
Path('processed').mkdir(parents=True, exist_ok=True)

# original_files = Path('originals').glob('*.png')
original_files = Path('originals').glob('**/*')

for original_file in original_files:
    inner_folders = f"{original_file.parent}/{original_file.name}"
    if inner_folders.startswith(original_folder):
        inner_folders = inner_folders.replace(original_folder, '')
        
    elif inner_folders.startswith(f"{original_folder}/"):
        inner_folders = original_file.parent.replace(f"{original_folder}/", '')


    if original_file.is_dir():       
        Path(f"{processed_folder}/{inner_folders}/").mkdir(parents=True, exist_ok=True)
        
    else:
        print(f'processing file: {original_file}')
        
        img = Image.open(original_file)
        rgba = img.convert('RGBA')
        datas = rgba.getdata()


        newData = []
        
        for item in datas:
            if item in alpha_colors:
                newData.append((255, 255, 255, 0))

            else:
                newData.append(item)
                              
        rgba.putdata(newData)
        rgba.save(f'{processed_folder}/{inner_folders}', 'PNG')