\ test_maths.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1748+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs
require sin_forth/lib/minus.fs     \ `-`
require sin_forth/lib/plus.fs      \ `+`
require sin_forth/lib/one-plus.fs  \ `1+`
require sin_forth/lib/one-minus.fs \ `1-`
require sin_forth/lib/store.fs     \ `!`
require sin_forth/lib/two-plus.fs  \ `2+`
require sin_forth/lib/two-minus.fs \ `2-`

boot-here

60 literal  05 literal + emit \ "A"
01 literal $41 literal + emit \ "B"
68 literal  01 literal - emit \ "C"
99 literal  31 literal - emit \ "D"
68 literal  1+           emit \ "E"
71 literal  1-           emit \ "F"
69 literal  2+           emit \ "G"
74 literal  2-           emit \ "H"

$00FF literal 1+ 1- emit \ "COPY"

ret,

4 data-stack
