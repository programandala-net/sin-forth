\ test_dot.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230505T1148+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

require sin_forth/lib/c-r.fs     \ `cr`
require sin_forth/lib/dot.fs     \ `dot`
require sin_forth/lib/dup.fs     \ `dup`
require sin_forth/lib/for.fs     \ `for`
require sin_forth/lib/literal.fs \ `literal`
require sin_forth/lib/plus.fs    \ `plus`
require sin_forth/lib/s-quote.fs \ `s"`
require sin_forth/lib/step.fs    \ `step`
require sin_forth/lib/type.fs    \ `type`

boot-here

exx, h push,

s"    0= " type    0 literal . cr
s"  128= " type  128 literal . cr
s" -128= " type -128 literal . cr
s"  255= " type  255 literal . cr

s" Numbers and chars 64..32:" type cr
32 literal
for r@ + 64 literal dup . emit step

h pop, exx,
ret,

8 data-stack
