# Steganography-Load-and-Save-message-into-Bitmap

Simple class for Loading and saving messages into images.
Data isn´t hashed or encrypted. String message is converted into byte array. Each byte is saved in seperate color channel of pixel. So pixel contains 3 bytes of data.

In first pixel is saved x step, y step and count. 
Steps are for identification of data pixels. Count is message length. 

Maximal Message length is 256 characters(byte limitation) and with long message pixel alternation is observable, because of placing pixels with fixed steps.

To used this simply call ImageProcessing.LoadMessage and ImageProccesing.SaveMessage.
