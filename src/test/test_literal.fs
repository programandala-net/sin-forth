\ test_literal.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1748+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs

: game ( -- ) 65 literal emit 66 literal emit 67 literal emit ;

4 data-stack
