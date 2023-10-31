from PIL import Image
import json

map_path = "maps/test_map.json"
tiles_reference_path = "maps/tiles_reference.json"

with open(map_path, "r") as map_file:
    with open(tiles_reference_path, "r") as tiles_reference_file:
        # Load Json files
        tiles_reference = json.load(tiles_reference_file)
        loaded_map = json.load(map_file)
        
        # Calculate rows and columns
        rows = len(loaded_map['floor_tiles'])
        max_column_len = len(max(loaded_map['floor_tiles'], key=len))

        # Caculate final image size
        width = tiles_reference['dimentions'][0] * max_column_len
        height = tiles_reference['dimentions'][1] * max_column_len
        final_image = Image.new("RGBA", (width, height), (0,0,0,0))
        
        # Populate the final image
        for i in range(rows):
            for j in range(len(loaded_map['floor_tiles'][i])):
                tile_png = f"maps/floor_tiles/{loaded_map['floor_tiles'][i][j]}.png"
                
                tile = Image.open(tile_png)
                tile.convert("RGBA")
               
                
                final_image.paste(tile, (j * tiles_reference['dimentions'][0], i * tiles_reference['dimentions'][1]))

        # Save the final image
        final_image.save("maps/floor_test.png", "PNG")
       