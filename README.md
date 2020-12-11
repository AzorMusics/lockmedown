# LockMeDown

## What is LockMeDown?

LockMeDown is a Open Source Encryption Program which reads every byte of the file you want to encrypt and multiplies the value of the byte with values coming from your chosen Password. This Program is working for all Desktop Operating Systems. You need the Dotnet Core Runtime to use it.

If someone wants to decrypt your File without having the exact password he will still get a file, but its insides are completely broken.

Its a fun little project and i didnt spent that much time working on it but it will work perfectly fine.

## How does it work?

Every Letter / Character has a value. LockMeDown gets the value of every character in your Password. When this is finished, LockMeDown reads all the Bytes of the File you want to encrypt. The Bytes of the File are now getting multiplied by the Values of the Letters (in a row).

Here is that process visualized with the Password "Test":

```
Character: T | Value: 84    |   84 * (Value of byte nr 1) = New Value of Byte 1
Character: e | Value: 101   |   101 * (Value of byte nr 2) = New Value of Byte 2
Character: s | Value: 115   |   115 * (Value of byte nr 3) = New Value of Byte 3
Character: t | Value: 116   |   116 * (Value of byte nr 4) = New Value of Byte 4

Character: T | Value: 84    |   84 * (Value of byte nr 5) = New Value of Byte 5
Character: e | Value: 101   |   101 * (Value of byte nr 6) = New Value of Byte 6

And so on until all bytes were overwritten...
```

## Usage

### For optimal usage you have to put the LockMeDown Directory into the Environment Variables (PATH)

Use the Command Prompt and direct into the LockMeDown Directory you just downloaded. When you are, you can use these Commands:

```
lockmedown --lock <password> <file path>       | It encrypts a File
lockmedown --unlock <password> <file path>     | It decrypts a File
lockmedown --bytecount <file path>             | It counts all bytes in a File
```
