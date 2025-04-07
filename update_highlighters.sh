#!/bin/bash

# Update all highlighter files
for file in Assets/Scripts/Highlighter/*Highlighter.cs; do
    if [ -f "$file" ]; then
        # Skip the base class
        if [[ "$file" == *"/PlacementHighlighter.cs" ]]; then
            continue
        fi
        
        # Update the file contents
        sed -i '' \
            -e 's/namespace Blokr/namespace Blokr.Highlighter/' \
            -e 's/using Blokr.Selector/using Blokr.Highlighter/' \
            -e 's/ : Selector, ISelector/ : PlacementHighlighter/' \
            "$file"
    fi
done
