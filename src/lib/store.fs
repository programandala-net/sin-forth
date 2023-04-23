\ lib/s-p-0.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require sin_forth/lib/pop-hl-de.fs \ `pop-hl-de`

get-order get-current

target-definitions

: ! ( x a -- )
  pop-hl-de
  e m ld,     \ ld (hl),e
  h incp,     \ inc hl
  d m ld, ;   \ ld (hl),d

  \ doc{
  \
  \ ! ( x a -- ) "store"
  \
  \ Store _x_ at _a_.
  \
  \ // XXX TODO
  \ // See also: `@`, `+!`, `2!`, `c!`.
  \ See also: `@`, `+!`.
  \
  \ }doc

set-current set-order
