\ test_rot.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230501T1433+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

require sin_forth/lib/c-r.fs       \ `cr`
require sin_forth/lib/emit.fs      \ `emit`
require sin_forth/lib/literal.fs   \ `literal`
require sin_forth/lib/minus-rot.fs \ `-rot`
require sin_forth/lib/rot.fs       \ `rot`
require sin_forth/lib/swap.fs      \ `swap`

: data ( -- c1 c2 c3 )
  'B' literal
  'm' literal
  'T' literal 
  ;

: print ( c1 c2 c3 -- )
  rot emit swap emit emit cr ;

boot-here

exx,
h push,

data cr print
data rot print

data cr print
data -rot print

h pop,
exx,
ret,

4 data-stack
