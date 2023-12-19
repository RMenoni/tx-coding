Set-Location -Path $PSScriptRoot

mongosh --verbose --eval "use tx;" --eval "db.shelf.deleteMany({});"
mongosh --verbose --eval "use tx;" --eval "db.sku.deleteMany({});"

(Get-Content -Raw -Path ..\shelf.json | ConvertFrom-Json).Cabinets | ConvertTo-Json -Depth 10 | mongoimport --db tx --collection shelf --jsonArray
mongoimport --db tx --collection shelf --collection sku --type csv --headerline --file ..\sku.csv
