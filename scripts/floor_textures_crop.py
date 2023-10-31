from pathlib import Path
from PIL import Image

import json

# Tiles
rows = 21
columns = 7
tile_size = 64
original_image_path = "maps/PC Computer - DOOM 2 - Floor Textures.png"
tiles_out_path = "maps/floor_tiles"

Path(tiles_out_path).mkdir(parents=True, exist_ok=True) 
original_image = Image.open(original_image_path)

x_offset = 5
y_offset = 5

# tiles_reference.json
tiles_reference_out_path = "maps"
tiles_reference = {
    "dimentions": [tile_size, tile_size],   
    "tile_names_list": []
}
tile_names_list = []

# Generate Tiles
for i in range(rows):
    for j in range(columns):
        left = (j * tile_size)+ (j+1) * x_offset
        top = (i * tile_size)+ (i+1) * y_offset
        right = (j+1) *tile_size + (j+1) * x_offset
        bottom = (i+1) * tile_size + (i+1) * y_offset
        
        cropped_image = original_image.crop((left, top, right, bottom))

        # Save the cropped image as PNG
        tile_name = f"{j + (columns*i)}.png"
        file_name = f"{tiles_out_path}/{tile_name}"
        
        print("Processing:", file_name)
        cropped_image.save(file_name , "PNG")
        
        # Add tile name to json reference
        tiles_reference["tile_names_list"].append(tile_name)
        
                
with open(f"{tiles_reference_out_path}/tiles_reference.json", 'w', encoding='utf-8') as f:
    json.dump(tiles_reference, f, ensure_ascii=False, indent=4)