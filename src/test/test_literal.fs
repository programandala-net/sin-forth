\ test_literal.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1933+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

40000 set-origin

begin-program

require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs

: game ( -- ) 65 literal emit 66 literal emit 67 literal emit ;

4 data-stack

end-program
