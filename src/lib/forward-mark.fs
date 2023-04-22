\ lib/forward-mark.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

get-order get-current

compiler-definitions

: >mark ( -- orig )
  memory> @ 2 - ;

  \ doc{
  \
  \ >mark ( C: -- orig ) "forward-mark"
  \
  \ Return the address _orig_ of the destination of a Z80 jump
  \ instruction that was just compiled, destination that must be later
  \ resolved by `>resolve`.
  \
  \ Used at the source of a forward branch.  Typically used after
  \ either `branch`, `0branch` or `?branch`.
  \
  \ See also: `<mark`.
  \
  \ }doc

set-current set-order
