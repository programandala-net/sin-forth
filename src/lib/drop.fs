\ lib/drop.fs

\ This file is part of Sin Forth.

\ This file adds `drop` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012240200.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

: drop ( x -- )
  ix incp, \ inc ix
  ix incp, \ inc ix 
  ;        \ ret

  \ doc{
  \
  \ drop ( x -- )
  \
  \ Remove _x_ from the stack.
  \
  \ See also: `2drop`, `nip`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-13: Start.
\
\ 2020-12-24: Remove unnecessary requirements. Improve comments.
