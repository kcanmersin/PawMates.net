import os
import glob

def read_csharp_files(directory):
    """
    Read all C# files in the specified directory and its subdirectories.
    
    Parameters:
        directory (str): The path to the directory to search for C# files.
    """
    # Construct the path pattern to match all .cs files
    path_pattern = os.path.join(directory, '**', '*.cs')
    
    # Use glob to find all files that match the pattern, including in subdirectories
    cs_files = glob.glob(path_pattern, recursive=True)
    
    for file_path in cs_files:
        try:
            with open(file_path, 'r', encoding='utf-8') as file:
                content = file.read()
                print(f"Content of {file_path}:\n{content}\n{'='*40}\n")
        except Exception as e:
            print(f"Failed to read {file_path}: {e}")

# Example usage
directory = ""
read_csharp_files(directory)
