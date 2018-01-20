# Usage
Create a Google Spreadsheets file like:

| key             | en    | es   | ... |
| --------------- | ----- | ---- | --- |
| WELCOME_MESSAGE | Hello | Hola | ... |
| ...             | ...   | ...  | ... |

Press the share button in order to generate a shareable link (accessible exclusively for anybode with the link) 

Modify the `Makefile` and replace link and select the desirable unity `StreamingAssets` path.

Run `npm install` in order to provision the required vendors to generate the `i18n.json`

Run `make i18n`

