\ test_s-backslash-type.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230505T1242+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

require sin_forth/lib/s-backslash-quote.fs \ `s\"`
require sin_forth/lib/type.fs              \ `type`

boot-here
exx, h push,

s\" line 1\rline 2\rand line 3!\r" type
s\" \x41\x42\x43 = ABC\r" type
s\" \x41\x42X\b\x43 = ABC\r" type
s\" A \"quoted\" word\r" type
s\" A backslash: '\\'\r" type

h pop, exx,
ret,

8 data-stack
