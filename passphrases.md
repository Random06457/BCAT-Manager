# How to get a title's passphrase

The titles' passphrases are stored in their respective "Control" NCA.<br>
These "Control" NCAs contain some files that start with "icon_" which are the title's icons and a "control.nacp" file which contains informations about the title (the title ID, the title name, the title version, etc...) including the title's passphrase.

### 1- How do I get these "Control" NCAs ?
To make it easier, I wrote a little homebrew that allows you to dump these "control" data very quickly without having to dump your whole nand.<br>
So all you have to do is : <br>
1- Download the homebrew [here](https://github.com/Random0666/NX-Title-Control-Dumper/releases). <br>
2- Go to the homebrew launcher and launch this homebrew. <br>
3- Press the A button to dump all your titles' "contol" data.<br>

Once done, on your SD card you'll have the extracted "control" data at `<nro folder>/Controls/full/<title iD>/` with the "icon.jpg" and "control.ncap".<br> <img src="https://raw.githubusercontent.com/Random0666/Useless-stuff/master/BCAT-Manager/images/sd.png"/>

### 2- How to get the passphrase from the control.ncap

So now, to get your passphrase, you have to open the control.nacp file from your extracted title's "control" data with any hex editor, go to offset 0x3100 and copy your 0x40 bytes long passphrase **as a string**.<img src="https://raw.githubusercontent.com/Random0666/Useless-stuff/master/BCAT-Manager/images/nacp.png"/>

___Note : If the passphrase is only a bunch of 0s, it probably means that your title doesn't use bcat___ 
