\ test_type.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230505T1117+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

require sin_forth/lib/b-l.fs       \ `bl`
require sin_forth/lib/c-r.fs       \ `cr`
require sin_forth/lib/count.fs     \ `count`
require sin_forth/lib/create.fs    \ `create`
require sin_forth/lib/emit.fs      \ `emit`
require sin_forth/lib/emits.fs     \ `emits`
require sin_forth/lib/literal.fs   \ `literal`
require sin_forth/lib/s-quote.fs   \ `s"`
require sin_forth/lib/space.fs     \ `space`
require sin_forth/lib/spaces.fs    \ `spaces`
require sin_forth/lib/type.fs      \ `type`

: the-end ( -- ) s" The End" type ;

create zx
"Sinclair ZX Spectrum" t-s,

boot-here
exx, h push,

s" a c1 3 with BL and 6 EMITs :" type cr
'a' literal emit
bl          emit
'c' literal emit
'1' literal emit
bl          emit
'3' literal emit cr

s" abc123 with 6 EMITs :" type cr
'a' literal emit
'b' literal emit
'c' literal emit
'1' literal emit
'2' literal emit
'3' literal emit cr

s" abc123 with 2 TYPEs :" type cr
s" abc" type
s" 123" type cr

s" again, separated by SPACE :" type cr
s" abc" type space
s" 123" type cr

s" TYPE a string compiled by" type cr
s" CREATE and T-S, " type cr
zx count type cr

s" 8 SPACES between parens:" type cr
'(' literal emit
8 literal spaces
')' literal emit cr

s" 16 hyphens with EMITS :" type cr
'-' literal 16 literal emits cr

s" Execute a word that TYPEs" type cr
s" its own string:" type cr
the-end

h pop, exx,
ret,

8 data-stack
