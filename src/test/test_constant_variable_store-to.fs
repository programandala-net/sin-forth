\ test_constant_variable_store-to.fs
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

require sin_forth/lib/constant.fs
require sin_forth/lib/c-fetch.fs
require sin_forth/lib/c-store.fs
require sin_forth/lib/c-variable.fs
require sin_forth/lib/emit.fs
require sin_forth/lib/fetch.fs
require sin_forth/lib/store.fs
require sin_forth/lib/store-to.fs
require sin_forth/lib/variable.fs

65 constant  letter-1   \ "A"
   variable  letter-2
67 constant  letter-3   \ "C"
   cvariable letter-4

: run ( -- )

  66 literal letter-2  ! \ "B"
  68 literal letter-4 c! \ "D"

  letter-1    emit       \ "A"
  letter-2  @ emit       \ "B"
  letter-3    emit       \ "C"
  letter-4 c@ emit       \ "D"

  letter-1 letter-2 !
  letter-2 @ emit       \ "A"
  68 literal !> letter-3
  letter-3   emit       \ "D"

  ;

4 data-stack
