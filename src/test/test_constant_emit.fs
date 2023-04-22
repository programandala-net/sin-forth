\ test_constant_emit.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1933+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

40000 set-origin

begin-program

require sin_forth/lib/constant.fs
require sin_forth/lib/emit.fs

65 constant zx

boot-here
zx emit ret,

4 data-stack

end-program
