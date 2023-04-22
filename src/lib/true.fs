\ lib/true.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1823+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

: true ( -- true )
  $FFFF h ldp#, \ ld hl,$FFFF
  push-hl ;

  \ doc{
  \
  \ true ( -- true )
  \
  \ Return a true flag, a single-cell value with all its bits
  \ set (equivalent to `-1`).
  \
  \ See also: `false`.
  \
  \ }doc

set-current set-order
