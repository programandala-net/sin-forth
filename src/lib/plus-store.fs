\ lib/s-p-0.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require pop-hl-de.fs \ `pop-hl-de`

get-order get-current

target-definitions

: +! ( n a -- )
  pop-hl-de
  m a ld,     \ ld a,(hl)
  e add,      \ add a,e
  a m ld,     \ ld (hl),a
  h incp,     \ inc hl
  m a ld,     \ ld a,(hl)
  d adc,      \ adc a,d
  a m ld, ;   \ ld (hl),a

  \ doc{
  \
  \ +! ( n|u a -- ) "plus-store"
  \
  \ Add _n|u_ to the single-cell number at _a_.
  \
  \ // XXX TODO
  \ // See also: `c+!`, `@`, `+`, `!`.
  \ See also: `@`, `+`, `!`.
  \
  \ }doc

set-current set-order
