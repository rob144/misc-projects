#Do a bulk rename of all files in current directory, replacing '-' with '_'
for filename in *-*; do mv "$filename" "${filename//-/_}"; done
