import os
import glob

def write_csharp_files_to_file(directory, max_size=1048576, output_prefix="combined_cs"):
    """
    Write all C# files from the specified directory and its subdirectories to one or more files,
    splitting them if they exceed a specified size.
    
    Parameters:
        directory (str): The path to the directory to search for C# files.
        max_size (int): Maximum size of each output file in bytes (default is 1MB).
        output_prefix (str): Prefix for the output files.
    """
    path_pattern = os.path.join(directory, '**', '*.cs')
    cs_files = glob.glob(path_pattern, recursive=True)

    file_number = 1
    current_size = 0
    output_file = open(f"{output_prefix}_{file_number}.txt", 'w', encoding='utf-8')

    for file_path in cs_files:
        try:
            with open(file_path, 'r', encoding='utf-8') as file:
                content = file.read()
                # Check if adding this file's content would exceed the max size
                if current_size + len(content.encode('utf-8')) > max_size:
                    # Close current file and open a new one
                    output_file.close()
                    file_number += 1
                    output_file = open(f"{output_prefix}_{file_number}.txt", 'w', encoding='utf-8')
                    current_size = 0  # Reset the current size counter

                # Write the content to the current output file
                output_file.write(f"Content of {file_path}:\n{content}\n{'='*40}\n")
                current_size += len(content.encode('utf-8'))
        
        except Exception as e:
            print(f"Failed to read {file_path}: {e}")

    output_file.close()

# Example usage
directory = ""
write_csharp_files_to_file(directory)
