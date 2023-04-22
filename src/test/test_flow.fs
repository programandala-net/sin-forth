\ test_flow.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

\ bye \ XXX TMP

40000 set-origin
s" test_flow" set-filename

begin-program

require sin_forth/lib/after.fs      \ `after`
require sin_forth/lib/begin.fs      \ `begin`
require sin_forth/lib/c-r.fs        \ `cr`
require sin_forth/lib/drop.fs       \ `drop`
require sin_forth/lib/dup.fs        \ `dup`
require sin_forth/lib/emit.fs       \ `emit`
require sin_forth/lib/equals.fs     \ `=`
require sin_forth/lib/for.fs        \ `for`
require sin_forth/lib/if.fs         \ `if`
require sin_forth/lib/less-than.fs  \ `<`
require sin_forth/lib/literal.fs    \ `literal`
require sin_forth/lib/one-minus.fs  \ `1-`
require sin_forth/lib/one-plus.fs   \ `1+`
require sin_forth/lib/plus.fs       \ `plus`
require sin_forth/lib/r-fetch.fs    \ `r@`
require sin_forth/lib/repeat.fs     \ `repeat`
require sin_forth/lib/step.fs       \ `step`
require sin_forth/lib/then.fs       \ `then`
require sin_forth/lib/until.fs      \ `until`
require sin_forth/lib/while.fs      \ `while`
require sin_forth/lib/zero-until.fs \ `zero-until`

boot-here

1 literal if 'A' literal emit then
0 literal if 'X' literal emit then
2 literal if 'B' literal emit then
0 literal if 'X' literal emit then
3 literal if 'C' literal emit then

\ Type from 'a' to 'z':
cr
'a' literal
begin dup '{' literal = 0 literal =
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
begin dup emit 1- dup '`' literal <
0until drop

\ Type from 'z' to 'a'
cr
host{ 'z' 'a' - } literal
for r@ 'a' literal + emit step

\ Type from '3' to '0'
cr
host{ '3' '0' - } literal
for r@ '0' literal + emit step

\ Type from '2' to '0'
cr
host{ '3' '0' - } literal
for after r@ '0' literal + emit then step

ret,

4 data-stack

end-program
