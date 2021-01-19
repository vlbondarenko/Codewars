## ASCII85 Encoding & Decoding

ASCII85 is a binary-to-ASCII encoding scheme that's used within PDF and Postscript, and which provides data-size savings over base 64. 
Your task is to extend the String object with two new methods, toAscii85 (to_ascii85 in ruby) and fromAscii85 (from_ascii85 in ruby), 
which handle encoding and decoding ASCII85 strings.

As Python does not allow modifying the built-in string class, for Python the task is to provide functions toAscii85(data) and fromAscii85(ascii85), 
which handle encoding and decoding ASCII85 strings (instead of string object methods).

As Swift strings are very picky about character encodings (and don't take kindly to storing binary data), in Swift, 
extend Data with a toAscii85 method and String with a fromAscii85 method.

The toAscii85 method should take no arguments and must encode the value of the string to ASCII85, without any line breaks or other whitespace added 
to the native ASCII85-encoded value.

#### Example:

        'easy'.toAscii85() should return <~ARTY*~>
        'moderate'.toAscii85() should return <~D/WrrEaa'$~>
        'somewhat difficult'.toAscii85() should return <~F)Po,GA(E,+Co1uAnbatCif~>

The fromAscii85 method should take no arguments and must decode the value of the string (which is presumed to be ASCII85-encoded text).

#### Example:

        '<~ARTY*~>'.fromAscii85() should return easy
        '<~D/WrrEaa\'$~>'.fromAscii85() should return moderate
        '<~F)Po,GA(E,+Co1uAnbatCif~>'.fromAscii85() should return somewhat difficult
    
You can learn all about ASCII85 here. And remember, this is a binary-to-ASCII encoding scheme, so the input isn't necessarily always a readable string! A brief summary of the salient points, however, is as follows:

1. In general, four binary bytes are encoded into five ASCII85 characters.
2. The character set that ASCII85 encodes into is the 85 characters between ASCII 33 (!) and ASCII 117 (u), as well as ASCII 122 (z), 
which is used for data compression (see below).
3. In order to encode, four binary bytes are taken together as a single 32-bit number (you can envision concatenating their binary representations, 
which creates a 32-bit binary number). You then serially perform division by 85, and add 33 to the remainder of each division to get the ASCII character 
value for the encoded value; the first division and addition of 33 is the rightmost character in the encoded five-character block, etc. 
(This is all represented well is the visualization in the Wikipedia page's example.)
4.If the last block to be encoded contains less than four bytes, it's padded with nulls to a total length of four bytes, and then after encoding, 
the same number of characters are removed as were added in the padding step.
5. If a block to be encoded contains all nulls, then that block is encoded as a simple z (ASCII 122) rather than the fully-encoded value of !!!!!.
6. The final encoded value is surrounded by <~ at the start and ~> at the end. In the wild, whitespace can be inserted as needed (e.g., line breaks for mail transport agents); 
in this kata, whitespace shouldn't be added to the final encoded value for the sake of checking the fidelity of the encoding.
7. Decoding applies the above in reverse; each block of five encoded characters is taken as its ASCII character codes, multiplied by powers 
of 85 according to the position in the block of five characters (again, see the Wikipedia example visualization), 
and then broken into four separate bytes to determine the corresponding binary values.
8. If a block to be decoded contains less than five characters, it is padded with u characters (ASCII 117), decoded appropriately, 
and then the same number of characters are removed from the end of the decoded block as us were added.
9. All whitespace in encoded values is ignored (as in, it's removed from the encoded data before the data is broken up into the five-character blocks to be decoded).
