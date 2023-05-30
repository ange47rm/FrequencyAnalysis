# Frequency Analysis

### Running instructions

1. Clone the project to your machine.
2. Build the project. This will create the bin folder.
3. In terminal, change directory to the net6.0 folder, where the executable file is (FrequencyAnalysis\bin\Debug\net6.0).
4. You can now run the command `.\FrequencyAnalysis.exe "file1"`. This will analyze the contents of "file1". Make sure to include double quotes when specifying the file name.

### Analyze your own text files
You can alternatively create your own .txt file and have it analyzed, however make sure the file is in the "text-files" folder (FrequencyAnalysis\text-files).

### Case sensitivity
The application, by default, is case sensitive, meaning a separate count will be generated for both the upper case and the lower case version of a letter.
You can switch case sensitivity off by passing in `"ci"`, as second argument after the file name, example: `.\FrequencyAnalysis.exe "file1" "ci"`.
This allows you to see how many times a letter is in the text, combining the amount of times the letter appears in both lower case and upper case form.
