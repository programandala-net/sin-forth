\ test_value.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230501T1057+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

require sin_forth/lib/emit.fs    \ `emit`
require sin_forth/lib/literal.fs \ `literal`
require sin_forth/lib/to.fs      \ `to`
require sin_forth/lib/value.fs   \ `value`

boot-here

exx,
h push,

\ NOTE: `value` is executed during the compilation, and it expects the
\ initial content of `zx` on the host data stack:

'0' value zx
zx emit

\ NOTE: `to` compiles code that will be executed at run-time, so the
\ value must be compiled by `literal`:

'1' literal to zx
zx emit

'2' literal to zx
zx emit

h pop,
exx,
ret,

4 data-stack
