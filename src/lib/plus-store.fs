\ lib/s-p-0.fs

\ This file is part of Sin Forth.

\ This file adds `s-p-0` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012111759.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>.
\
\ 2020-12-11: Document.
