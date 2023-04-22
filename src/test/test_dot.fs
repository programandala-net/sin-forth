\ test_dot.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1745+0200.

\ ==============================================================

40000 set-origin
s" test_dot" set-filename

begin-program

require sin_forth/lib/c-r.fs       \ `cr`
require sin_forth/lib/dot.fs       \ `dot`
require sin_forth/lib/dup.fs       \ `dup`
require sin_forth/lib/for.fs       \ `for`
require sin_forth/lib/literal.fs   \ `literal`
require sin_forth/lib/plus.fs      \ `plus`
require sin_forth/lib/s-literal.fs \ `sliteral`
require sin_forth/lib/step.fs      \ `step`
require sin_forth/lib/type.fs      \ `type`

boot-here

exx, h push,

"   0= " sliteral type    0 literal . cr
" 128= " sliteral type  128 literal . cr
"-128= " sliteral type -128 literal . cr
" 255= " sliteral type  255 literal . cr

"Numbers and chars 64..32:" sliteral type cr
32 literal
for r@ + 64 literal dup . emit step

h pop, exx,
ret,

8 data-stack

end-program
