\ lib/c-store.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1823+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require pop-hl-de.fs \ `pop-hl-de`

get-order get-current

target-definitions

: c! ( c ca -- )
  pop-hl-de \ call pop_hl_de
  e m ld,   \ ld (hl),e
  ;         \ ret

  \ doc{
  \
  \ c! ( c ca -- ) "c-store"
  \
  \ Store _c_ at _ca_.
  \
  \ See also: `!`, `2!`, `c@`.
  \
  \ }doc

set-current set-order
