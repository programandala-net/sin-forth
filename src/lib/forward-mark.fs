\ lib/forward-mark.fs

\ This file is part of Sin Forth.

\ This file adds `>mark` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
