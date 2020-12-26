\ lib/c-store.fs

\ This file is part of Sin Forth.

\ This file adds `c!` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261908.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
