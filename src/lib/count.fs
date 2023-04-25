\ lib/count.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require pop-hl.fs  \ `pop-hl`
require push-hl.fs \ `push-hl`

: count ( ca1 -- ca2 len2 )
  pop-hl   \ call pop_hl
  m a ld,  \ ld a,(hl)
  h incp,  \ inc hl
  push-hl  \ call push_hl
  0 h ld#, \ ld h,0
  a l ld,  \ ld l,a
  push-hl  \ call push_hl
  ;        \ ret

  \ doc{
  \
  \ count ( ca1 -- ca2 len2 )
  \
  \ Return the character string specification for the counted
  \ string stored at _ca1_. _ca2_ is the address of the first
  \ character after _ca1_. _len_ is the  contents of the character
  \ at _c1_, which is the  length in characters of the string at
  \ _c2_.
  \
  \ }doc
