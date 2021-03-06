#! /usr/bin/env gforth

\ test_type.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260307.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_type" set-filename

begin-program

require sin_forth/lib/b-l.fs       \ `bl`
require sin_forth/lib/c-r.fs       \ `cr`
require sin_forth/lib/count.fs     \ `count`
require sin_forth/lib/create.fs    \ `create`
require sin_forth/lib/drop.fs      \ `drop`
require sin_forth/lib/emit.fs      \ `emit`
require sin_forth/lib/emits.fs     \ `emits`
require sin_forth/lib/literal.fs   \ `literal`
require sin_forth/lib/s-literal.fs \ `sliteral`
require sin_forth/lib/space.fs     \ `space`
require sin_forth/lib/spaces.fs    \ `spaces`
require sin_forth/lib/type.fs      \ `type`

: the-end ( -- ) "The End" sliteral type ;

create zx
"Sinclair ZX Spectrum" t-s,

boot-here
exx, h push,

"a c1 3 with BL and 6 EMITs :" sliteral type cr
'a' literal emit
bl          emit
'c' literal emit
'1' literal emit
bl          emit
'3' literal emit cr

"abc123 with 6 EMITs :" sliteral type cr
'a' literal emit
'b' literal emit
'c' literal emit
'1' literal emit
'2' literal emit
'3' literal emit cr

"abc123 with 2 TYPEs :" sliteral type cr
s" abc" sliteral type
s" 123" sliteral type cr

"again, separated by SPACE :" sliteral type cr
s" abc" sliteral type space
s" 123" sliteral type cr

"TYPE a string compiled by" sliteral type cr
"CREATE and T-S, " sliteral type cr
zx count type cr

"8 SPACES between parens:" sliteral type cr
'(' literal emit
8 literal spaces
')' literal emit cr

"16 hyphens with EMITS :" sliteral type cr
'-' literal 16 literal emits cr

"Execute a word that TYPEs" sliteral type cr
"its own string:" sliteral type cr
the-end

h pop, exx,
ret,

8 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-25: Start.
\
\ 2020-12-26: Complete. Update with `cr`. Use also `create`, `t-s,`
\ and `count`. Test `bl`, `space`, `spaces` and `emits`. Display
\ descriptions of the tests.
