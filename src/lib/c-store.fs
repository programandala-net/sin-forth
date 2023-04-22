\ lib/c-store.fs

\ This file is part of Sin Forth.

\ This file adds `c!` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
