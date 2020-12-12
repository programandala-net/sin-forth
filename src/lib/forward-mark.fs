\ lib/forward-mark.fs

\ This file is part of Sin Forth.

\ This file adds `>mark` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072206.
\ See change log at the end of the file.

\ ==============================================================

require here.fs  \ `here`
require comma.fs \ `,`

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
  \ // XXX TODO
  \ // See also: `<mark`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-12: Finish and document.
