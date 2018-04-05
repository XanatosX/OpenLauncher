# Open launcher
This project is trying to provide a open source program launcher for windows

The key features are as followed:

1. Allow to add project via project.json file
2. Providing auto patch functionality for every project

The idea is to create a working launcher for any application you can imagine.

If you want to contribute feel free to fork the project and create a pull request.

# Download

There will be a download in the future, at the moment clone the source code and build it on your own. You will need the **.NET Framwork 4.6** and the **Newtonsoft.Json package** with the **version v11.0.2**.

You can find the Newtonsoft homepage [here][NewtonSoftJSON]

**Please keep in mind this is an alpha state at the moment**

# How to use

You need to provide a **project.json** for importing into the launcher. This files contains all the data the launcher need to know. As Example

    {
      "ImageUrl": "Some URL to an image file (jpg or PNG)",
      "Name": "The name of the program",
      "HomeURL": "A URL to the website of the project"
    }

To make your project downloadable you need to add a another json-file (OpenLauncher.json) to your website (The json-file must be placed in the same dictionary as the one you entered in the HomeURL in your project.json). 

This file only contains one setting
    
    {
    	DownloadMainFolder: "Relativ path to the folder on the Server containing the project files (non zipped)",
    }

This will forward the downloader to the correct folder. Keep in mind that the project you are providing cannot be zipped on the server, you will need to add the ready to use project on your webserver!

To create the last two json files needed for the updater you will need to use the Open launcher.

Once opened click on **"Project" -> "Create server downloadable"**

In the dialog showing up choose an input folder (This is the folder with your ready to use project). And a output folder, keep in mind that this folder must be empty and writeable!

Now press the "Create" button, you will be asked if you want to create the project configuration as well. Click on "yes" in the dialog. A new window will appear, drag and drop the files from your input folder into the list view which should act as starter for your application. You can add as many as you want, to rename the display name or delete an entry use the right mouse button.

Don't worry if the file path shows only the selected file name, the start up is relative to the project folder in the launcher!

After you have pressed the "Done" button all the files will be copied to the output folder with two additional files. These files will tell the launcher which files he needs to download, he checks again the check sum in the entries if this is different to the local files he will download this file again. The "ProjectConfig.json" will contain all the information for the launcher to finally start your app, if you are creating this file by hand you need to add this to the "UpdateInfo.json" by hand! Without this file you cannot start the app in the launcher.

After you created have done this you need to upload the whole folder content to your website. You need to put this into the folder you entered in your OpenLauncher.json.

If you add your project.json to the launcher you should see a download button. Try if everything is working fine before sending the project.json to your customers.

**Keep in mind to update your "Create server downloadable" everytime you update your project and upload this to your webserver!**

# License

This software is license under the [GNU General Public License 3][GNULicense]

[GNULicense]: https://www.gnu.org/licenses/gpl-3.0.en.html
[NewtonSoftJSON]: https://www.newtonsoft.com/json


