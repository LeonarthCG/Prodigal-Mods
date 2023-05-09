# Custom Colors
This is a simple mod for Prodigal which allows players to specify custom player character palettes in a JSON file, which can then be freely selected from while playing the game.

This mod relies on MelonLoader, so be sure to visit https://melonwiki.xyz/#/ and follow the installation guide, if you haven't already.

The mod also has a dependancy of Newtonsoft.Json.dll, which is under the MIT license. It is included with the mod, but you can also just get it from https://www.newtonsoft.com/json
## Installation
Install MelonLoader v0.6.1 Open-Beta, If you haven't already, by visiting https://melonwiki.xyz/#/
Finally, drag the following files to your Prodigal Mods folder:
- CustomColors.dll
- Newtonsoft.Json.dll
- CustomColors.json
## Controls
Simply use PageUp and PageDown while playing the game to navigate through your palettes.
## Files
- Source: This folder contains source files for the mod, feel free to check the code for yourself.
- CustomColors.dll: This is the main file for the mod, evidently it goes in the Mods folder. If you don't know where that is, open Steam and click properties for Prodigal, then under Local Files click on Browse and you should be able to see the Mods folder, if you followed the MelonLoader installation guide. If it's not there you can also just make it yourself.
- CustomColors.README.md: That's this file, you are reading it right now. Thank you for that.
- Newtonsoft.Json.dll: This is a dependancy the mod uses to read JSON files. A copy of this should be in the Mods folder, so copy it there if it isn't already.
- Newtonsoft.Json.LICENSE.md: This is the license for the aforementioned dependancy.
- CustomColors.json: This is the file you will be modifying to create your own palettes. The first palette listed in this file will be the one that is applied by default when the game loads. Note that this file is read only once, when the game starts, so if you modify this file you will have to quit the game to apply any changes.
## Format Explanation
Open CustomColors.json in your favorite plain text editor, it should look something like this:
```
{
	"color_list": [
		{
			"name": "This palette's name"
			"a1": {
				"r": 233,
				"g": 186,
				"b": 154,
				"a": 255
			},
			"a2": {
				"r": 127,
				"g": 111,
				"b": 172,
				"a": 255
			},
			...
		}
		...
	]
}
```
So, let's break it down.

This is a JSON file, which always start with `{` and end with `}`.
In between those the first thing we see is `"color_list": [`, which is closed by the `]` at the end of the file.

So far, all these things I have mentioned do not need to be modified, ever, so that's less stuff we need to worry about.

The elements we actually care about are the ones inside the color list, here's a full example of one:
```
{
	"name": "Tess",
	"a1": {
		"r": 233,
		"g": 186,
		"b": 154,
		"a": 255
	},
	"a2": {
		"r": 127,
		"g": 111,
		"b": 172,
		"a": 255
	},
	"a3": {
		"r": 54,
		"g": 57,
		"b": 67,
		"a": 255
	},
	"a4": {
		"r": 54,
		"g": 57,
		"b": 67,
		"a": 255
	},
	"b1": {
		"r": 233,
		"g": 186,
		"b": 154,
		"a": 255
	},
	"b2": {
		"r": 127,
		"g": 111,
		"b": 172,
		"a": 255
	},
	"b3": {
		"r": 233,
		"g": 186,
		"b": 154,
		"a": 255
	},
	"b4": {
		"r": 120,
		"g": 95,
		"b": 172,
		"a": 255
	}
}
```
## Adding, removing and modifying palettes
To add a new palette you can copy and paste one of these elements inside of the `color_list` and modify the values. Evidently if you want to delete a palette you can simply remove its corresponding element from the list, and if you want to modify it you can change its values.

Keep in mind that the closing curly bracket of the element must be followed by `,` only if there is another element in the list after it, and it must not be followed by `,` if it's the last element of the list.

The  `name` is used by the MelonLoader console to display the current palette's name, and can also give a hint as to what it's meant to look like to people reading the JSON file.

`a1` through `b4` are the colors you can modify, each of which has 4 components: red, green, blue and alpha (opacity), simply modify these components to whichever values you would like, in the range of 0 to 255. An alpha of 0 seems to give trouble, so set it to 1 for transpaprency instead.

Here is a lsit of what each color is used for:
* a1: Main skin tone, as well generally just the white color, used for things like the spots on Oran's hair that are lit up the most.
* a2: Main hair and clothing color.
* a3: Eyes.
* a4: Outline and darkest shadows. This and a3 are usually the same.
* b1: Skin shadows? It's like three pixels on Oran's face, and only in a few of the frames. This is usually the same as a1.
* b2: Hair and clothing highlights. This is usually the same as a2, but when a2 is the same as a4, like with the Hot Pink color, this will be a lighter color than those two, so that Oran is not a blotch.
* b3: Unused, as far as I can tell.
* b4: Spin attack charge effect. This one ignores alpha entirely.
