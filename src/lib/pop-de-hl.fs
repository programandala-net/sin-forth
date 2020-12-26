\ lib/pop-de-hl.fs

\ This file is part of Sin Forth.

\ This file adds `pop-de-hl` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260311.
\ See change log at the end of the file.

\ ==============================================================
\ pop-hl-de {{{1

get-order get-current

target-definitions

: pop-de-hl ( x1 x2 | d -- )
                      \             ; T Cycles
  0 ix e ftx,         \ ld e,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix d ftx,         \ ld d,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix l ftx,         \ ld l,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  0 ix h ftx,         \ ld h,(ix+0) ;  19
  ix incp,            \ inc ix      ;  10
  ;                   \ ret         ;  10
                      \             ; 126 total (126 average with push-hl-de)

  \ doc{
  \
  \ pop-de-hl  ( x1 x2 | d -- )
  \
  \ First pop _x2_ to into the ``DE`` Z80 register. Then pop
  \ _x1_ into the ``HL`` Z80 register. The cell pair _x1 x2_
  \ can be seen also a double number _d_, equivalent to the content of
  \ the theoretic register pair ``DEHL``, being ``DE`` its high part
  \ (on top of stack) and ``HL`` its low part.
  \
  \ See also: `push-de-hl`, `pop-hl-de`, `pop-de`, `pop-hl`, `pop-a`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-26: Update the documentation with `pop-a`.
