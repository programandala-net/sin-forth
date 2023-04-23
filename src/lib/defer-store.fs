\ lib/defer-store.fs
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

: defer! ( dea1 dea2 -- )
  pop-hl-de
  h incp,     \ inc hl
  e m ld,     \ ld (hl),e
  h incp,     \ inc hl
  d m ld, ;   \ ld (hl),d

  \ doc{
  \
  \ defer! ( dea1 dea2 -- ) "defer-store"
  \
  \ Set the deferred word _dea2_ to execute _dea1_.
  \
  \ // XXX TODO
  \ // See also: `defer@`, `defer`, `>action`.
  \ See also: `defer`.
  \
  \ }doc

set-current set-order
