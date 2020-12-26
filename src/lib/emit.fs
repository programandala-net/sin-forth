\ lib/emit.fs

\ This file is part of Sin Forth.

\ This file adds `emit` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260124.
\ See change log at the end of the file.

\ ==============================================================

require pop-hl.fs \ `pop-hl`

get-order get-current

target-definitions

: emit ( c -- )
  pop-hl
  l a ld,       \ ld a,l
: emit-a
  $10 rst,      \ rst $10
  $FF a ld#,    \ ld a,$FF
  #23692 sta, ; \ ld(sys_scr_ct),a ; no "scroll?" message

  \ doc{
  \
  \ emit ( c -- )
  \
  \ Display character _c_.
  \
  \ See also: `emit-a`, `cr`.
  \
  \ }doc

  \ doc{
  \
  \ emit-a ( -- )
  \
  \ Display the character contained in the ``A`` Z80 register.
  \
  \ See also: `emit`, `cr`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Start.
\
\ 2020-12-09: Move `require` to the top.
\
\ 2020-12-11: Improve documentation.
\
\ 2020-12-26: Update documentation with `cr`.
