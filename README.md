# C# - Project RSA Encryption.

## Overview

The goal of this project is to save an Encrypted text, using RSA Algorithim, in the database, and recover the same text by decrypting it.

## Endpoints
### <API>/v1/text-management
#### Input JSON


| Name | Type                                                         | Description                                                  |
| ----- | -------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------- |
| text_data            | string | text to save in the DB                                         | 
| encryption           | bool   | determines whether to do encryption                            |
| key_size             | int    | size of the encryption key ( allowed only 1024, 2048 and 4096) | 
| private_key_password | string | password to open the text later                                |

#### Return JSON
| Name | Type                                                         | Description                                                  |
| ----- | -------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------- |
| UUID            | int    | Corresponding ID to the text in the DB                                                       | 
| pkcs8           | string | Encrypted private key (encryption using TripleDES and Private Key Password from input)       |


### <API>/v1/text-management?id={text_id}
#### Input


| Name | Type                                                         | Description                                                  |
| ----- | -------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------- |
| text_id | int | Corresponding ID to the text in the DB | 


#### Return JSON
| Name | Type                                                         | Description                                                  |
| ----- | -------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------- |
| decryptedText | string    | Decrypted saved text  | 
