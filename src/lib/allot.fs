\ lib/allot.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1143+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require d-p.fs        \ `dp`
require plus-store.fs \ `+!`

: allot ( n -- ) dp +! ;
