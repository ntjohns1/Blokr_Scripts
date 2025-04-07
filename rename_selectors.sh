#!/bin/bash

# Create Highlighter directory if it doesn't exist
mkdir -p "Assets/Scripts/Highlighter"

# Move and rename files
for file in Assets/Scripts/Selector/*Selector.cs; do
    if [ -f "$file" ]; then
        # Skip special files
        if [[ "$file" == *"/ISelector.cs" ]] || [[ "$file" == *"/Selector.cs" ]] || [[ "$file" == *"/MoveSelector.cs" ]]; then
            continue
        fi
        
        # Get the base name without extension
        base=$(basename "$file" .cs)
        # Remove "Selector" and add "Highlighter"
        newname="${base/Selector/Highlighter}"
        
        # Move and rename the file
        mv "$file" "Assets/Scripts/Highlighter/$newname.cs"
        
        # Update the file contents
        sed -i '' \
            -e 's/namespace Blokr.Selector/namespace Blokr.Highlighter/' \
            -e 's/using Blokr.Selector/using Blokr.Highlighter/' \
            -e "s/class ${base}/class ${newname}/" \
            -e 's/: PieceSelector/: PlacementHighlighter/' \
            "Assets/Scripts/Highlighter/$newname.cs"
    fi
done

# Clean up old files
rm "Assets/Scripts/Selector/Selector.cs" "Assets/Scripts/Selector/ISelector.cs"
