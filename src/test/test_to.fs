\ test_to.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230501T1106+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

require sin_forth/lib/c-r.fs      \ `cr`
require sin_forth/lib/constant.fs \ `constant`
require sin_forth/lib/emit.fs     \ `emit`
require sin_forth/lib/literal.fs  \ `literal`
require sin_forth/lib/one-plus.fs \ `1+`
require sin_forth/lib/to.fs       \ `to`
require sin_forth/lib/value.fs    \ `value`

boot-here

exx,
h push,

\ NOTE:
\
\ `value` and `constant` are executed during the compilation, and they
\ expect the initial values on the host data stack.
\
\ `to` compiles code that will be executed at run-time, so its
\ argument must be compiled by `literal`.

'0' value digit
digit emit

digit 1+ to digit
digit emit

digit 1+ to digit
digit emit

cr

'A' constant letter
letter emit

letter 1+ to letter
letter emit

letter 1+ to letter
letter emit


h pop,
exx,
ret,

4 data-stack
