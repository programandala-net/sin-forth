\ lib/pop-a.fs

\ This file is part of Sin Forth.

\ This file adds `pop-a` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260250.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

: pop-a ( -- c )
                      \             ; T Cycles
  a 0 ix ftx,         \ ld (ix+0),a ;  19
  ix incp,            \ inc ix      ;  10
  ix incp,            \ inc ix      ;  10
  ;                   \ ret         ;  10
                      \             ; 049 total (58.5 average with pop-a)

  \ doc{
  \
  \ pop-a ( c -- )
  \
  \ Pop the content _c_ to the ``A`` Z80 register.
  \
  \ See also: `push-a`, `pop-hl`, `pop-de`, `pop-de-hl`, `pop-hl-de`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
