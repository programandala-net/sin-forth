\ lib/count.fs

\ This file is part of Sin Forth.

\ This file adds `count` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012251752.
\ See change log at the end of the file.

\ ==============================================================

require pop-hl.fs  \ `pop-hl`
require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

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

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-00-00: Start.
