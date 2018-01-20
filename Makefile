i18n:
	rm -rf i18n.csv i18n.json
	curl "https://docs.google.com/spreadsheets/d/xxxxxxxxxxxxxxxxxxxxxxx/export?format=csv" > i18n.csv
	mkdir -p ../Assets/StreamingAssets
	node csv_to_json.js > ../Assets/StreamingAssets/i18n.json
	rm -rf i18n.csv
