\ test_flow.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1250+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

begin-program

require sin_forth/lib/after.fs        \ `after`
require sin_forth/lib/begin.fs        \ `begin`
require sin_forth/lib/c-r.fs          \ `cr`
require sin_forth/lib/drop.fs         \ `drop`
require sin_forth/lib/dup.fs          \ `dup`
require sin_forth/lib/emit.fs         \ `emit`
require sin_forth/lib/equals.fs       \ `=`
require sin_forth/lib/for.fs          \ `for`
require sin_forth/lib/greater-than.fs \ `>`
require sin_forth/lib/if.fs           \ `if`
require sin_forth/lib/less-than.fs    \ `<`
require sin_forth/lib/literal.fs      \ `literal`
require sin_forth/lib/not-equals.fs   \ `<>`
require sin_forth/lib/one-minus.fs    \ `1-`
require sin_forth/lib/one-plus.fs     \ `1+`
require sin_forth/lib/plus.fs         \ `plus`
require sin_forth/lib/r-fetch.fs      \ `r@`
require sin_forth/lib/repeat.fs       \ `repeat`
require sin_forth/lib/step.fs         \ `step`
require sin_forth/lib/then.fs         \ `then`
require sin_forth/lib/until.fs        \ `until`
require sin_forth/lib/while.fs        \ `while`
require sin_forth/lib/zero-equals.fs  \ `0=`
require sin_forth/lib/zero-until.fs   \ `0until`

boot-here
exx, h push,

1 literal if 'A' literal emit then
0 literal if 'X' literal emit then
2 literal if 'B' literal emit then
0 literal if 'X' literal emit then
3 literal if 'C' literal emit then

\ Type from 'a' to 'z':
cr
'a' literal
begin dup '{' literal <>
while dup emit 1+
repeat drop

\ Type from 'z' to 'a'
cr
'z' literal
begin dup emit 1- dup '`' literal =
until drop

\ Type from 'z' to 'a'
cr
'z' literal
begin
dup emit 1- dup '`' literal > 0=
0until drop

\ Type from 'z' to 'a'
cr
'z' 'a' host{ - } literal
for r@ 'a' literal + emit step

\ Type from '3' to '0'
cr
'3' '0' host{ - } literal
for r@ '0' literal + emit step

\ Type from '2' to '0'
cr
'3' '0' host{ - } literal
for after r@ '0' literal + emit then step

h pop, exx,
ret,

8 data-stack

end-program
